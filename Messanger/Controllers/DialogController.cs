using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserManager.Helpers;
using UserManager.Models;
using Messanger.Interfaces;

namespace Messanger.Controllers
{
    [ApiController]
    [Route("api/dialog")]
    public class DialogController : ControllerBase
    {
        public DialogController(IDialogRepository dialogRepository)
        {
            this.dialogRepository = dialogRepository;
        }

        private IDialogRepository dialogRepository;

        [HttpPost("get")]
        public async Task<IActionResult> GetDialod([FromForm]DialogModel model)
        {
            Dialog dialog = await dialogRepository.GetDialog(model);

            if (dialog != null)
            {
                return Ok(dialog);
            }

            return NotFound();
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetUserDialogs(long id)
        {
            List<Dialog> dialogs;

            try
            {
                dialogs = await dialogRepository.GetUserDialogsAsync(id);

                return Ok(dialogs);
            }
            catch
            {
            }

            return BadRequest();
        }
    }
}
