using AutoMapper;
using Edmund.API.Domain.Models;
using Edmund.API.Resources.Classroom;
using Edmund.API.Resources.EducationalStage;
using Edmund.API.Resources.Mark;
using Edmund.API.Resources.MarksRecord;
using Edmund.API.Resources.Subject;
using Edmund.API.Resources.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveEducationalStageResource, EducationalStage>();
            CreateMap<SaveEducationalStageSubjectResource, EducationalStageSubject>();
            CreateMap<SaveMarkResource, Mark>();
            CreateMap<SaveMarksRecordResource, MarksRecord>();
            CreateMap<SaveSubjectResource, Subject>();
            CreateMap<SaveUserSubjectResource, UserSubject>();
            CreateMap<SaveClassroomResource, Classroom>();
        }
    }
}
