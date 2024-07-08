using Business_Logic_Layer;
using Data_Logic_Layer.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CIPlatFormWebApi_V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly BALMission _balMission;

        public MissionController(BALMission balMission)
        {
            _balMission = balMission;
        }

        [HttpPost]
        [Route("CreateMission")]
        public async Task<ResponseResult> CreateMission([FromBody] MissionDto model)
        {
            ResponseResult result = new ResponseResult();

            try
            {
                result.Data = await _balMission.CreateMission(model);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = ResponseStatus.Error;
            }

            return result;
        }

        [HttpGet]
        [Route("GetMissions")]
        public async Task<ResponseResult> GetMissionsWithDetails()
        {
            ResponseResult result = new ResponseResult();

            try
            {
                result.Data = await _balMission.GetMissionsWithDetails();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = ResponseStatus.Error;
            }

            return result;
        }

        [HttpGet]
        [Route("GetMissionById/{MissionId}")]
        public async Task<ResponseResult> GetMissionDetailsById(int MissionId)
        {
            ResponseResult result = new ResponseResult();

            try
            {
                result.Data = await _balMission.GetMissionDetailsById(MissionId);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = ResponseStatus.Error;
            }

            return result;
        }

        [HttpPut]
        [Route("UpdateMission/{MissionId}")]
        public async Task<ResponseResult> UpdateMission(int MissionId, [FromBody] MissionDto model)
        {
            ResponseResult result = new ResponseResult();

            try
            {
                result.Data = await _balMission.UpdateMission(MissionId, model);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = ResponseStatus.Error;
            }

            return result;
        }

        [HttpDelete]
        [Route("DeleteMission/{id}")]
        public async Task<ResponseResult> DeleteMission(int id)
        {
            ResponseResult result = new ResponseResult();

            try
            {
                result.Data = await _balMission.DeleteMission(id);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = ResponseStatus.Error;
            }

            return result;
        }
    }
}
