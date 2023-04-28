using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.ViewModel;

namespace OnlineShop.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly OnlineShopeEntity onlineShopeEntity;
        public UserController(UserManager<User> _userManager, SignInManager<User> _signInManager, OnlineShopeEntity _onlineShopeEntity)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            onlineShopeEntity = _onlineShopeEntity;
        }
        public async Task<IActionResult> Register(AddUserViewModel addUser)
        {
            

            if (ModelState.IsValid == false)
            {
                return View();
            }
            else
            {
                User user = new User();
                user.UserName = addUser.UserName;
                user.Email = addUser.Email;
                user.firstName = addUser.FirstName;
                user.lastName = addUser.LastName;
                IdentityResult result = await userManager.CreateAsync(user, addUser.Password);
                if (result.Succeeded == false)
                {
                    result.Errors.ToList().ForEach(

                        i =>
                        {
                            ModelState.AddModelError("", i.Description);
                        }

                        );
                    return View();
                }
                else
                {
                    Cart cart = new Cart();
                    cart.Quantity = 0;
                    cart.UserId=user.Id;
                    onlineShopeEntity.Carts.Add(cart);
                    onlineShopeEntity.SaveChanges();
                    return RedirectToAction("Get", "Product");
                }

            }
        }
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }
            else
            {
                
                var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded == false)
                {
                    ModelState.AddModelError("", "This Passwoed or User Name is incorect");
                    return View();
                }
                else
                {
                    return RedirectToAction("Get", "Product");
                }

            }
        }

        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    } 
}
