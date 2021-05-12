// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace JohnnyR_Prueba.Pages.Personas
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\mdela\Desktop\Proyectos\C#\JohnnyR_Prueba\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mdela\Desktop\Proyectos\C#\JohnnyR_Prueba\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\mdela\Desktop\Proyectos\C#\JohnnyR_Prueba\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\mdela\Desktop\Proyectos\C#\JohnnyR_Prueba\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\mdela\Desktop\Proyectos\C#\JohnnyR_Prueba\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\mdela\Desktop\Proyectos\C#\JohnnyR_Prueba\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\mdela\Desktop\Proyectos\C#\JohnnyR_Prueba\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\mdela\Desktop\Proyectos\C#\JohnnyR_Prueba\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\mdela\Desktop\Proyectos\C#\JohnnyR_Prueba\_Imports.razor"
using JohnnyR_Prueba;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\mdela\Desktop\Proyectos\C#\JohnnyR_Prueba\_Imports.razor"
using JohnnyR_Prueba.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\mdela\Desktop\Proyectos\C#\JohnnyR_Prueba\_Imports.razor"
using JohnnyR_Prueba.Data.Personas;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\mdela\Desktop\Proyectos\C#\JohnnyR_Prueba\_Imports.razor"
using JohnnyR_Prueba.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Lista")]
    public partial class Lista : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 46 "C:\Users\mdela\Desktop\Proyectos\C#\JohnnyR_Prueba\Pages\Personas\Lista.razor"
      

    public string Filtro { get; set; }

    //Creamos una lista con las personas en la Base de datos
    static List<Persona> GetPersonas() => new JohnnyRondon_PruebaContext().Persona.ToList();

    //Nueva lista para hacer la busqueda de personas
    public List<Persona> PersonasFiltradas { get; set; } = GetPersonas();
    private void Filtrar()
    {
        PersonasFiltradas = PersonasFiltradas.Where(
            p => p.Nombre.ToLower().Contains(Filtro.ToLower())
        ).ToList();
    }

    //Mostramos la lista completa de personas
    private void MostrarTodos()
    {
        PersonasFiltradas = GetPersonas();
        Filtro = "";
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
