using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using EngLabAPI.Repository;
using MediatR;

namespace EngLabAPI.Command.Student
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IStudentRepostory _studentRepostory;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public CreateStudentCommandHandler(IStudentRepostory studentRepostory, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _studentRepostory = studentRepostory;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<EngLabAPI.Model.Entities.Student>(request);

            try
            {
                await _unitOfWork.BeginTransactionAsync();
                _studentRepostory.Add(student);
                await _unitOfWork.SaveChangeAsync();
                await _unitOfWork.CommitAsync();
                return await Task.FromResult(1);
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                return await Task.FromResult(0);
            }
        }
    }
}