using AutoMapper;
using LabSchoolAPI.DTOs;
using LabSchoolAPI.Models;

namespace FichaCadastroApi.AutoMapper
{
    public class ConfigurationMapper : Profile
    {
        public ConfigurationMapper()
        {
            // USUARIO
            CreateMap<UsuarioModel, UsuarioCreateDTO>();
            CreateMap<UsuarioModel, UsuarioUpdateDTO>();
            CreateMap<UsuarioModel, UsuarioReadDTO>();
            CreateMap<UsuarioModel, UsuarioLoginDTO>();
            CreateMap<UsuarioModel, UsuarioResetarSenhaDTO>();

            // WHITELABEL
            CreateMap<WhiteLabelModel, WhiteLabelCreateDTO>();
            CreateMap<WhiteLabelModel, WhiteLabelUpdateDTO>();
            CreateMap<WhiteLabelModel, WhiteLabelReadDTO>();

            // ENDEREÇO
            CreateMap<EnderecoModel, EnderecoCreateDTO>();
            CreateMap<EnderecoModel, EnderecoUpdateDTO>();
            CreateMap<EnderecoModel, EnderecoReadDTO>();

            // EXERCICIO
            CreateMap<ExercicioModel, ExercicioCreateDTO>();
            CreateMap<ExercicioModel, ExercicioUpdateDTO>();
            CreateMap<ExercicioModel, ExercicioReadDTO>();

            // AVALIAÇÃO
            CreateMap<AvaliacaoModel, AvaliacaoCreateDTO>();
            CreateMap<AvaliacaoModel, AvaliacaoUpdateDTO>();
            CreateMap<AvaliacaoModel, AvaliacaoReadDTO>();

            // ATENDIMENTO
            CreateMap<AtendimentoModel, AtendimentoCreateDTO>();
            CreateMap<AtendimentoModel, AtendimentoUpdateDTO>();
            CreateMap<AtendimentoModel, AtendimentoReadDTO>();


        }
    }
}