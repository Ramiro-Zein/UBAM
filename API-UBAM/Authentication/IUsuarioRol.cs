﻿using API_UBAM.Models;

namespace API_UBAM.Interfaces;

public interface IUsuarioRol
{
    Guid Id_Usuario { get; set; }
    Guid Id_Rol { get; set; }
    Usuario Usuario { get; set; }
    Rol Rol { get; set; }
}