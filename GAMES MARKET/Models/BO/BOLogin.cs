using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAMES_MARKET.Models.BO
{
    public class BOLogin
    {
        public void addUser(UsuariosModel usuariosModel)
        {
            using (var bd = new Games_MarketEntities())
            {
                usuarios usuario = new usuarios();
                usuario.nombre = usuariosModel.nombre;
                usuario.apellidos = usuariosModel.apellidos;
                usuario.email = usuariosModel.email;
                usuario.contrasena = usuariosModel.contrasena;
                bd.usuarios.Add(usuario);
                bd.SaveChanges();
            }
        }

            public UsuariosModel Login(UsuariosModel usuariosModel)
        {
            var bd = new Games_MarketEntities();
            usuarios usuario = bd.usuarios.Where(p => p.email.Equals(usuariosModel.email) && p.contrasena.Equals(usuariosModel.contrasena)).FirstOrDefault();
            usuariosModel.id_usuario = usuario.id_usuario;
            usuariosModel.apellidos = usuario.apellidos;


            return usuariosModel;
            
        }
        public usuarios getUsuarioByEmail(string email)
        {
            var bd = new Games_MarketEntities();
            usuarios usuario = bd.usuarios.Where(p => p.email.Contains(email)).FirstOrDefault();
            return usuario;
        }

    }
}