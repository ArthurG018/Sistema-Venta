// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static WebAppVentaDSI.Data.ApplicationDbContext;

namespace WebAppVentaDSI.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager; 

        public IndexModel(
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            /*
             AGREGO EL INPUT MODEL CLASS
             
             */
            //codigo
            [Display(Name = "Nomrbes")]
            [MaxLength(80, ErrorMessage = "El campo no debe de tener mas de 80 caracteres")]
            public string? Nombre { get; set; }

            [Display(Name = "Apellidos")]
            [MaxLength(80, ErrorMessage = "El campo no debe de tener mas de 80 caracteres")]
            public string? Apellidos { get; set; }

            [Display(Name = "Direccion")]
            [MaxLength(100, ErrorMessage = "El campo no debe de tener mas de 100 caracteres")]
            public string? Direccion { get; set; }

        }

        private async Task LoadAsync(Usuario user)
        {
            /**/
            //var usuario = await _userManager.Get(user);
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            //Nombre obtiene el nombre de la bd
            var nombre = user.Nombre;
            var apellido = user.Apellidos;
            var direccion = user.Direccion;
            
            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Nombre = nombre,
                Apellidos=apellido,
                Direccion= direccion
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                //agregar
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            //Nombre se actualiza
            //se evalua si es diferente al anterior
            var nombre = user.Nombre;
            if (Input.Nombre != nombre)
            {
                user.Nombre = Input.Nombre; // Actualizamos el valor del nombre del usuario
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to update your profile.";
                    return RedirectToPage();
                }
            }
            //apellido
            var apellido = user.Apellidos;
            if (Input.Apellidos != apellido)
            {
                user.Apellidos = Input.Apellidos; // Actualizamos el valor del nombre del usuario
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to update your profile.";
                    return RedirectToPage();
                }
            }
            //direccion:
            var direccion = user.Direccion;
            if (Input.Direccion != direccion)
            {
                user.Direccion = Input.Direccion; // Actualizamos el valor del nombre del usuario
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to update your profile.";
                    return RedirectToPage();
                }
            }


            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
