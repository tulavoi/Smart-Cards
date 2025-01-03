﻿using api.Helpers;
using SmartCards.DTOs.Course;
using SmartCards.Models;

namespace SmartCards.Interfaces
{
    public interface ICourseRepository
    {
        Task CreateAsync(Course course, int viewPerId, int editPerId);
        Task<Course?> GetByIdAsync(int id);
        Task<List<Course>> GetAllAsync(CourseQueryObject query);
        string GetErrorMessage(CreateCourseRequestDTO courseDTO); 
    }
}
