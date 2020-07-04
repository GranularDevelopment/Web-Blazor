﻿using Grpc.Core;
using Models;
using ServiceProtocol;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Serverside
{
    public class ProjectServicesImpl : ProjectServices.ProjectServicesBase, IGenericCRUD
    {

        public override Task<ActionResponse> CreateProjectRequest(ProjectRequest request, ServerCallContext context)
        {
            return this.GenericCreate<ProjectRequest>(request);
        }

        //public override Task<ProjectRequestList> GetMatchingProjectRequests(ProjectRequest ProjectRequestToMatch, ServerCallContext context)
        //{
        //    ProjectRequestList i = new ProjectRequestList();
        //    this.GenericWrappedInvoke<ProjectRequest>( ProjectRequestToMatch, db => from r in db.ProjectRequests where r.Name == ProjectRequestToMatch.Name select r, (x) => i.ProjectRequests.Add(x) );
        //    return Task.FromResult(i);
        //}
        //public override Task<ProjectRequestList> GetAllProjectRequests(Google.Protobuf.WellKnownTypes.Empty empty, ServerCallContext context)
        //{
        //    ProjectRequestList i = new ProjectRequestList();
        //    this.GenericWrappedInvoke<ProjectRequest>( null, db => from r in db.ProjectRequests select r, (x) => i.ProjectRequests.Add(x) );
        //    return Task.FromResult(i);
        //}
    }
}
