using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using EditorialMvc.DataAccess.Repositorio.IRepositorio;
using EditorialMvc.Models;
using EditorialMvc.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace EditorialMvc.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IWebHostEnvironment _hostEnvironment;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            IUnidadTrabajo unidadTrabajo,
            IWebHostEnvironment hostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _unidadTrabajo = unidadTrabajo;
            _hostEnvironment = hostEnvironment;

        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            public string Nombre { get; set; }

            public string Direccion { get; set; }

            public string Canton { get; set; }

            public string Provincia { get; set; }

            public string CodigoPostal { get; set; }

            public string Telefono { get; set; }

            public string Role { get; set; }

            public int? CompaniaId { get; set; }

            public IEnumerable<SelectListItem> Companias { get; set; }

            public IEnumerable<SelectListItem> Roles { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            Input =
                new InputModel
                {
                    Companias = _unidadTrabajo.Categorias.Listar().Select(s => new SelectListItem { Text = s.Nombre, Value = s.Id.ToString() }),
                    Roles = _roleManager.Roles.Where(w => w.Name != SD.Roles.Simple).Select(s => s.Name).Select(s => new SelectListItem { Text = s, Value = s })
                };

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user =
                    new Usuario
                    {
                        UserName = Input.Email,
                        Email = Input.Email,
                        Nombre = Input.Nombre,
                        Direccion = Input.Direccion,
                        Canton = Input.Canton,
                        Provincia = Input.Provincia,
                        CodigoPostal = Input.CodigoPostal,
                        PhoneNumber = Input.Telefono,
                        CompaniaId = Input.CompaniaId,
                        Role = Input.Role
                    };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    if (string.IsNullOrEmpty(Input.Role))
                    {
                        await _userManager.AddToRoleAsync(user, SD.Roles.Simple);
                    }
                    else
                    {
                        if (user.CompaniaId > 0)
                        {
                            await _userManager.AddToRoleAsync(user, SD.Roles.Compania);
                        }
                        else
                        {
                            await _userManager.AddToRoleAsync(user, user.Role);
                        }
                    }

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    string plantilla =
                    string.Join(
                    Path.DirectorySeparatorChar.ToString(),
                    _hostEnvironment.WebRootPath,
                    "plantillas",
                    "correos",
                    "Register.html");
                    string htmlMessage = string.Empty;
                    using (StreamReader reader = System.IO.File.OpenText(plantilla))
                    {
                        htmlMessage = reader.ReadToEnd();
                    }
                    htmlMessage =
                    string.Format(
                    htmlMessage,
                    "Bienvenido a Editorial Mvc.",
                    DateTime.Now.ToString("dddd, d MMMM yyyy"),
                    ((Usuario)user).Nombre,
                    user.Email,
                    HtmlEncoder.Default.Encode(callbackUrl)
                    );
                    await _emailSender.SendEmailAsync(user.Email, "Confirmación de Correo Electrónico", htmlMessage);

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(user.Role))
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return LocalRedirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Usuario", new { Area = "Admin" });
                        }
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
