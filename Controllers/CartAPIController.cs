using BookStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreAPI.Controllers
{
    [Route("CartAPI")]
    [ApiController]
    public class CartAPIController : ControllerBase
    {

        CartDB cartDB = new CartDB();

        // GET: api/<CartAPIController>
        [HttpGet]
        [Route("GetAllCart")]
        public List<Cart> Get()
        {
            return cartDB.ViewCart();
        }
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<CartAPIController>/5

        [HttpGet]
        [Route("GetCartWithUserId/{userid}")]
        public List<Cart> Get(int userid)
        {
            var getCart = cartDB.ViewCartwithUserID(userid); //.Where(x => x.User_Id == id).FirstOrDefault();
            return getCart;
        }

        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CartAPIController>

        [HttpPost]
        [Route("AddToCart")]
        public void Post(Cart objCart)
        {
            cartDB.InsertCart(objCart);
        }


        // PUT api/<CartAPIController>/5

        [HttpPut]
        [Route("UpdateCart/{userid}/{bookid}/{qty}")]
        public void Put(int userid, int bookid, int qty, Cart objCart)
        {
            var updateCart = cartDB.ViewCart().Where(x => x.User_Id==userid && x.Book_Id==bookid).FirstOrDefault();
            if (updateCart != null)
            {
                updateCart.Qty = qty;
                cartDB.UpdateCart(updateCart);
            }
        }

        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<CartAPIController>/5
        //[HttpDelete("{id}")]
        [HttpDelete]
        [Route("DeleteCart/{userid}/{bookid}")]
        public void Delete(int userid,int bookid)
        {
            cartDB.DeleteCart(userid, bookid);
        }
    }
}
