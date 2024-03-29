using Microsoft.AspNetCore.Mvc;
using WebAPIs.Hospital.CleanCrud.BLL;

namespace WebAPIs.Hospital.CleanCrud.APIs.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class DoctorsController : Controller
    {
        private readonly IDoctorsManager _doctorsManager;

        public DoctorsController(IDoctorsManager doctorsManager)
        {
            this._doctorsManager = doctorsManager;
        }
        [HttpGet]
        public ActionResult<List<DoctorsReadDTO>> GetAll()
        {
            return _doctorsManager.GetAllForUsers();
        }

        [HttpPost]
        public ActionResult Add(DoctorAddDTO doctorAddDTO)
        { 
            _doctorsManager.Add(doctorAddDTO);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut]
        public ActionResult Update(DoctorsUpdateDTO doctorsUpdateDTO)
        {
            var result = _doctorsManager.Update(doctorsUpdateDTO);
            if(!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<DoctorGetDetailByIdsDTO> GetDetailsById(int id)
        {
            DoctorGetDetailByIdsDTO? doctor = _doctorsManager.GetDetailsById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return doctor;
        }
    }
}
