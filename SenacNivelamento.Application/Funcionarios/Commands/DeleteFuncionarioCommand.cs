﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using SenacNivelamento.Application.Common.Interfaces;
using SenacNivelamento.Application.Funcionarios.Repositories;
using SenacNivelamento.Application.Funcionarios.Validations;
using SenacNivelamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SenacNivelamento.Application.Funcionarios.Commands
{
    public class DeleteFuncionarioCommand : FuncionarioCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new DeleteFuncionarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        public class DeleteFuncionarioCommandHandler : IRequestHandler<DeleteFuncionarioCommand, FuncionarioCommandResult>
        {
            private readonly IFuncionarioWritingRepository _funcionarioContext;

            public DeleteFuncionarioCommandHandler(
                IFuncionarioWritingRepository funcionarioContext)
            {
                _funcionarioContext = funcionarioContext;
            }

            public async Task<FuncionarioCommandResult> Handle(DeleteFuncionarioCommand request, CancellationToken cancellationToken)
            {
                if (!request.IsValid())
                {
                    var response = new FuncionarioCommandResult();
                    response.CopyErrorsFromValidations(request.ValidationResult);
                    return response;
                }

                var entity = await _funcionarioContext.FirstOrDefaultAsync(c => c.Id == request.Id);

                if (entity == null)
                {
                    var response = new FuncionarioCommandResult();
                    response.AddNotification(nameof(Funcionario), "Registro não foi encontrado");
                    return response;
                }

                _funcionarioContext.Remove(entity.Id);
                await _funcionarioContext.SaveChangesAsync(cancellationToken);

                return new FuncionarioCommandResult()
                {
                    Id = entity.Id
                };
            }
        }
    }
}

