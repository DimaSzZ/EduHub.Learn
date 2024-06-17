﻿using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Domain.Entities;
using EduHub.StudentService.Infrastructure.Repositories.UoW;

namespace EduHub.StudentService.Infrastructure.Repositories;

public class StudentRepository : BaseRepository<Student>, IStudentRepository
{
    public StudentRepository(StudentUnitOfWork studentUnitOfWork) : base(studentUnitOfWork)
    {
    }
}