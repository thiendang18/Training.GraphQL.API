using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.GraphQL.API.IRepositories;
using Training.GraphQL.API.Models;

namespace Training.GraphQL.API.GraphQLDemo.GraphQLTypes
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType(IRoleRepository roleRepository, IDepartmentRepository departmentRepository, IUserAssetRepository userAssetRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id of User");
            Field(x => x.Name).Description("Name of User");
            Field(x => x.RoleId).Description("Role Id of User");
            Field(x => x.DepartmentId).Description("Department Id of User");
            Field<RoleType>(
                   "role",
                    resolve: context =>
                    {
                         return roleRepository.GetRole(context.Source.RoleId);
                    });
            Field<DepartmentType>(
                    "department",
                    resolve: context =>
                    {
                        return departmentRepository.GetDepartment(context.Source.DepartmentId);
                    });
            Field<ListGraphType<UserAssetType>>(
                    "userAssets",
                     resolve: context =>
                      {
                          return userAssetRepository.GetUserAssetsByUserId(context.Source.Id);
                      });

        }
    }
}
