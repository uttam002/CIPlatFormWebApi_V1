using System.Collections.Generic;
using System.Threading.Tasks;
using Data_Logic_Layer.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data_Logic_Layer
{
    public class DALMissionSkill : IMissionSkill
    {
        // Simulating database with an in-memory list for simplicity
        private readonly List<Skill> _skills = new List<Skill>();

        public Task<List<Skill>> GetMissionSkills()
        {
            return Task.FromResult(_skills);
        }

        public Task<string> CreateMissionSkill(Skill model)
        {
            model.Id = _skills.Count + 1;
            wait _skills.Skill.AddAsync(model);
            await _skills.SaveChangesAsync();
            return Task.FromResult("Skill created successfully.");
        }

        public Task<string> UpdateMissionSkill(int missionSkillId, Skill model)
        {
            var skill = _skills.Find(s => s.Id == missionSkillId);
            if (skill != null)
            {
                skill.Name = model.Name;
                skill.Status = model.Status;
                return Task.FromResult("Skill updated successfully.");
            }
            return Task.FromResult("Skill not found.");
        }

        public Task<Skill> GetMissionSkillById(int missionSkillId)
        {
            var skill = _skills.Find(s => s.Id == missionSkillId);
            return Task.FromResult(skill);
        }

        public Task<string> DeleteMissionSkill(int id)
        {
            var skill = _skills.Find(s => s.Id == id);
            if (skill != null)
            {
                _skills.Remove(skill);
                return Task.FromResult("Skill deleted successfully.");
            }
            return Task.FromResult("Skill not found.");
        }
    }
}
