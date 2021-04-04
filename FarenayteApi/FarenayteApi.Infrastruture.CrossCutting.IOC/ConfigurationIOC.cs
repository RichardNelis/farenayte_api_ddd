using Autofac;
using FarenayteApi.Application.Interfaces;
using FarenayteApi.Application.Service;
using FarenayteApi.Domain.Core.Interfaces.Repositorys;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Domain.Services.Services;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Map;
using FarenayteApi.Infrastruture.Repository.Repositorys;

namespace FarenayteApi.Infrastruture.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Registra IOC

            #region IOC Application
            builder.RegisterType<ApplicationServiceUsuario>().As<IApplicationServiceUsuario>();
            builder.RegisterType<ApplicationServicePessoaJuridica>().As<IApplicationServicePessoaJuridica>();
            builder.RegisterType<ApplicationServicePessoaFisica>().As<IApplicationServicePessoaFisica>();
            builder.RegisterType<ApplicationServicePublicacao>().As<IApplicationServicePublicacao>();
            builder.RegisterType<ApplicationServiceComentario>().As<IApplicationServiceComentario>();
            builder.RegisterType<ApplicationServiceAutorizacao>().As<IApplicationServiceAutorizacao>();
            builder.RegisterType<ApplicationServicePesquisa>().As<IApplicationServicePesquisa>();
            #endregion

            #region IOC Services
            builder.RegisterType<ServiceUsuario>().As<IServiceUsuario>();
            builder.RegisterType<ServicePessoaJuridica>().As<IServicePessoaJuridica>();
            builder.RegisterType<ServicePessoaFisica>().As<IServicePessoaFisica>();
            builder.RegisterType<ServicePublicacao>().As<IServicePublicacao>();
            builder.RegisterType<ServiceComentario>().As<IServiceComentario>();
            builder.RegisterType<ServicePesquisa>().As<IServicePesquisa>();
            #endregion

            #region IOC Repositorys SQL
            builder.RegisterType<RepositoryUsuario>().As<IRepositoryUsuario>();
            builder.RegisterType<RepositoryPessoaJuridica>().As<IRepositoryPessoaJuridica>();
            builder.RegisterType<RepositoryPessoaFisica>().As<IRepositoryPessoaFisica>();
            builder.RegisterType<RepositoryPublicacao>().As<IRepositoryPublicacao>();
            builder.RegisterType<RepositoryComentario>().As<IRepositoryComentario>();
            builder.RegisterType<RepositoryPesquisa>().As<IRepositoryPesquisa>();
            #endregion

            #region IOC Mapper
            builder.RegisterType<MapperUsuario>().As<IMapperUsuario>();
            builder.RegisterType<MapperPessoaJuridica>().As<IMapperPessoaJuridica>();
            builder.RegisterType<MapperPessoaFisica>().As<IMapperPessoaFisica>();
            builder.RegisterType<MapperPublicacao>().As<IMapperPublicacao>();
            builder.RegisterType<MapperComentario>().As<IMapperComentario>();
            builder.RegisterType<MapperAutorizacao>().As<IMapperAutorizacao>();
            builder.RegisterType<MapperPesquisa>().As<IMapperPesquisa>();
            #endregion

            #endregion
        }
    }
}
