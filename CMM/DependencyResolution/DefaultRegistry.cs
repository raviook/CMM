// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CMM.DependencyResolution {
    using StructureMap;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using Dao.Entities;
    using Services.UserServices;
    using Dao.Models.UserModels;
    using Dao.Models.MemberModels;
    using Services.MemberServices;
    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                });
            var CMMContext = new CMMdbEntities();
            CMMContext.Configuration.ProxyCreationEnabled = false;
            For<CMMdbEntities>().Use(CMMContext);
            //For<IExample>().Use<Example>();
            //services

            For<IUserServices>().Use<UserServices>();
            For<IMemberServices>().Use<MemberServices>();

            //Dao
            For<IUserDao>().Use<UserDao>();
            For<IMemberDao>().Use<MemberDao>();
        }

        #endregion
    }
}
