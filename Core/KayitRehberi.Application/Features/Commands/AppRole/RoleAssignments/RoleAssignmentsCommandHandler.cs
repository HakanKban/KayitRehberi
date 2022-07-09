using KayitRehberi.Application.Features.Commands.AppUser.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A = KayitRehberi.Domain.Entities.Identity;

namespace KayitRehberi.Application.Features.Commands.AppRole.RoleAssignments
{
    public class RoleAssignmentsCommandHandler : IRequestHandler<RoleAssignmentsCommandRequest, RoleAssignmentsCommandResponse>
    {
        readonly RoleManager<A.AppRole> _roleManager;
        
        readonly UserManager<A.AppUser> _userManager;

        public RoleAssignmentsCommandHandler(RoleManager<A.AppRole> roleManager, UserManager<A.AppUser> userManager)
        {
            _roleManager = roleManager;

            _userManager = userManager;
        }

        public async Task<RoleAssignmentsCommandResponse> Handle(RoleAssignmentsCommandRequest request, CancellationToken cancellationToken)
        {
           // Admin ve editör rollerinin oluşturulması
            await _roleManager.CreateAsync(new() { Name = "admin", Id = Guid.NewGuid().ToString() });
            await _roleManager.CreateAsync(new() { Name = "editor", Id = Guid.NewGuid().ToString() });

            //Admin kullanıcısı
            var userAdmin = new A.AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "HakanAdmin",
                Email = "admin@gmail.com",
            };

            //Admin kullanıcısı oluşturma ve rol atama
            await _userManager.CreateAsync(userAdmin, "Hakan123");
            await _userManager.AddToRoleAsync(userAdmin, "admin");

            //Editör kullanıcısı
            var userEditor = new A.AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "HakanEditor",
                Email = "editor@gmail.com",
            };

            //Editör kullanıcısı oluşturma ve rol atama
            await _userManager.CreateAsync(userEditor, "Hakan123");
            await _userManager.AddToRoleAsync(userEditor, "editor");


            RoleAssignmentsCommandResponse response = new() { Succeded = true, Message = "Deneme" };


            return response;

        }
    }
}
