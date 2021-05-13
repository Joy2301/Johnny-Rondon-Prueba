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
#line 1 "C:\Users\mdela\Desktop\Proyectos\C#\Johnny-Rondon-Prueba\JohnnyR_Prueba\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mdela\Desktop\Proyectos\C#\Johnny-Rondon-Prueba\JohnnyR_Prueba\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\mdela\Desktop\Proyectos\C#\Johnny-Rondon-Prueba\JohnnyR_Prueba\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\mdela\Desktop\Proyectos\C#\Johnny-Rondon-Prueba\JohnnyR_Prueba\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\mdela\Desktop\Proyectos\C#\Johnny-Rondon-Prueba\JohnnyR_Prueba\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\mdela\Desktop\Proyectos\C#\Johnny-Rondon-Prueba\JohnnyR_Prueba\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\mdela\Desktop\Proyectos\C#\Johnny-Rondon-Prueba\JohnnyR_Prueba\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\mdela\Desktop\Proyectos\C#\Johnny-Rondon-Prueba\JohnnyR_Prueba\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\mdela\Desktop\Proyectos\C#\Johnny-Rondon-Prueba\JohnnyR_Prueba\_Imports.razor"
using JohnnyR_Prueba;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\mdela\Desktop\Proyectos\C#\Johnny-Rondon-Prueba\JohnnyR_Prueba\_Imports.razor"
using JohnnyR_Prueba.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\mdela\Desktop\Proyectos\C#\Johnny-Rondon-Prueba\JohnnyR_Prueba\_Imports.razor"
using JohnnyR_Prueba.Data.Personas;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\mdela\Desktop\Proyectos\C#\Johnny-Rondon-Prueba\JohnnyR_Prueba\_Imports.razor"
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
#line 57 "C:\Users\mdela\Desktop\Proyectos\C#\Johnny-Rondon-Prueba\JohnnyR_Prueba\Pages\Personas\Lista.razor"
      

    private IEnumerable<Persona> persona { get; set; }
    private string Estado { get; set; }
    private string Filtro { get; set; }

    //Traemos la lista de personas desde la base de datos
    protected override async Task OnInitializedAsync()
    {
        try
        {
            persona = await PersonaService.GetAllPersonas();
            PersonasFiltradas = persona.ToList();
        }
        catch (Exception e)
        {
            
            Estado = e.Message;
        }
    }

    //Nueva lista para hacer la busqueda de personas
    private List<Persona> PersonasFiltradas { get; set; }    
    private void Filtrar()
    {
        PersonasFiltradas = persona.Where(
            p => p.Nombre.ToLower().Contains(Filtro.ToLower())
        ).ToList();
    }

    //Mostramos la lista completa de personas
    private void MostrarTodos()
    {
        PersonasFiltradas = persona.ToList();
        Filtro = "";
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IPersonaService PersonaService { get; set; }
    }
}
#pragma warning restore 1591
