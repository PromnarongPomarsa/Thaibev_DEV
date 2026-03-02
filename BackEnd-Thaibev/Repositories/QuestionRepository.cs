using BackEnd_Thaibev.Data;
using BackEnd_Thaibev.Models;
using BackEnd_Thaibev.Models.Dto;
using BackEnd_Thaibev.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_Thaibev.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private ResponseDto _response;
        private readonly AppDbContext _db;
        public QuestionRepository(AppDbContext db)
        {
            _response = new ResponseDto();
            _db = db;
        }

        public async Task<ResponseDto> saveQuestion(TbTQuestion entity)
        {
            try
            {
                _db.ChangeTracker.Clear();
                _db.tb_t_question.Add(entity);
                await _db.SaveChangesAsync();
                _response.Result = entity;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message.ToString();
            }
            return _response;
        }
        public async Task<ResponseDto> saveChoiceList(List<TbTChoiceItems> entity)
        {
            try
            {
                _db.ChangeTracker.Clear();
                _db.tb_t_choice_items.AddRange(entity);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message.ToString();
            }
            return _response;
        }
        public async Task<ResponseDto> getQuestionAll()
        {
            try
            {
                List<TbTQuestion> listData = await _db.tb_t_question.OrderBy(i => i.id).ToListAsync();

                if (listData.Count == 0)
                {
                    _response.IsSuccess = false;
                    _response.Message = "No reacord found";
                    _response.Result = listData;
                }

                _response.Result = listData;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message.ToString();
            }
            return _response;
        }
        public async Task<ResponseDto> getChoiceItemsAll()
        {
            try
            {
                List<TbTChoiceItems> listData = await _db.tb_t_choice_items.AsNoTracking().OrderBy(i => i.id).ToListAsync();
                if (listData.Count == 0)
                {
                    _response.IsSuccess = false;
                    _response.Message = "No reacord found";
                }
                _response.Result = listData;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message.ToString();
            }
            return _response;
        }
        public async Task<ResponseDto> getChoiceByQuestionId(int question_id)
        {
            try
            {
                List<TbTChoiceItems> getData = await _db.tb_t_choice_items.AsNoTracking().Where(p => p.ref_question_id == question_id).ToListAsync();
                _response.Result = getData;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message.ToString();
            }
            return _response;
        }
        public async Task<ResponseDto> getQuestionById(int question_id)
        {
            try
            {
                TbTQuestion getData = await _db.tb_t_question.FirstOrDefaultAsync(p => p.id == question_id);
                _response.Result = getData;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message.ToString();
            }
            return _response;
        }
        public async Task<ResponseDto> deleteQuestion(TbTQuestion entity)
        {
            try
            {
                _db.ChangeTracker.Clear();
                _db.tb_t_question.Remove(entity);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message.ToString();
            }
            return _response;
        }
        public async Task<ResponseDto> deleteChoiceList(List<TbTChoiceItems> entity)
        {
            try
            {
                _db.ChangeTracker.Clear();
                _db.tb_t_choice_items.RemoveRange(entity);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message.ToString();
            }
            return _response;
        }
    }
}
