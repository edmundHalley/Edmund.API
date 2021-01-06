using AutoMapper;
using Edmund.API.Domain.Models;
using Edmund.API.Resources;
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
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<User, UserResource>();
            CreateMap<EducationalStage, EducationalStageResource>();
            CreateMap<EducationalStageSubject, EducationalStageSubjectResource>();
            CreateMap<Mark, MarkResource>();
            CreateMap<MarksRecord, MarksRecordResource>();
            CreateMap<Subject, SubjectResource>();
            CreateMap<UserSubject, UserSubjectResource>();
            CreateMap<Classroom, ClassroomResource>();
        }
    }
}
