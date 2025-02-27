﻿using System;
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

        public UsuariosModel login(UsuariosModel usuariosModel)
        {
            var bd = new Games_MarketEntities();
            usuarios usuario = bd.usuarios.Where(p => p.email.Equals(usuariosModel.email) && p.contrasena.Equals(usuariosModel.contrasena)).FirstOrDefault();
            if(usuario == null)
            {
                return null;
            }
            usuariosModel.id_usuario = usuario.id_usuario;
            usuariosModel.nombre = usuario.nombre;
            usuariosModel.apellidos = usuario.apellidos;

            return usuariosModel;
        }
        public usuarios getUsuarioById(int id)
        {
            var bd = new Games_MarketEntities();
            usuarios usuario = bd.usuarios.Where(p => p.id_usuario.Equals(id)).FirstOrDefault();
            return usuario;
        }
        public usuarios getUsuarioByEmail(string email)
        {
            var bd = new Games_MarketEntities();
            usuarios usuario = bd.usuarios.Where(p => p.email.Equals(email)).FirstOrDefault();
            return usuario;
        }
        public String randomPassword()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();
            for (int i = 0; i < 8; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            String randompas = new String(stringChars);
            return randompas;
        }

    }
}