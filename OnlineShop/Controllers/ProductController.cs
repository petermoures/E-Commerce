using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using OnlineShop.ViewModel;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly OnlineShopeEntity onlineShope;
        public ProductController(OnlineShopeEntity _onlineShope)
        {
            onlineShope = _onlineShope;
        }
        [Authorize]
        public IActionResult Get()
        {
            var pto=onlineShope.Products.Include(i=>i.category).ToList();
            return View(pto);
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
       
        public IActionResult Details(int id)
        {
            var produ = onlineShope.Products.Include(i=>i.category).FirstOrDefault(i=>i.Id==id);
            return View(produ);
        }

        public IActionResult AddToCart(int id,string userId)
        {
           Cart cart= onlineShope.Carts.Include(i=>i.Productss).FirstOrDefault(a => a.UserId == userId);
            foreach (var item in cart.Productss)
            {
                var cat = onlineShope.Categories.FirstOrDefault(i => i.CateId == item.CategoryId);
                item.category = cat;
            }
            
           if (cart.Quantity==0&&cart.Productss==null)
            {
                var  p = onlineShope.Products.Include(i => i.category).FirstOrDefault(a => a.Id == id);
                cart.Quantity = 1;
                cart.Productss.Add(p) ;

                onlineShope.Carts.Update(cart);
                onlineShope.SaveChanges();

                return View(cart);
            }
            else 
            {
                var p1 = onlineShope.Products.Include(i => i.category).FirstOrDefault(i => i.Id == id);
                cart.Quantity += 1;
                cart.Productss.Add(p1);
                onlineShope.Carts.Update(cart);
                onlineShope.SaveChanges();
                return View(cart);
            }
             
                        
        }
        //public IActionResult RemoveFeomCart(int id)
         // {
           // List<Item> cart=ViewBag.cart;
            //int index=IndexProduct(id);
            // if(index!=-1)
             // {
              // if( cart[index].Quantity>1)
               // {
                  //  cart[index].Quantity -= 1;
                    
               // }
               // else 
               // {
                  //  cart.Remove(new Item { productss = onlineShope.Products.Include(i => i.category).FirstOrDefault(m => m.Id == id), Quantity = 1 });
               // }
              // ViewBag.cart=cart;
             // }
            
             
            //return RedirectToAction("Index");
          //}
       // public int IndexProduct(int prodf)
       // {
            //for (int i=0;i< prod.Count;i++)
            //{
               // if(prod[i].productss.Id == prodf)
               // {
                   // return i;
                //}
                
            //}
            //return -1;
       // }
    }
}
