using Data_Logic_Layer.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data_Logic_Layer
{
    public class DALMissionTheme : IMissionTheme
    {
        private readonly AppDbContext _context;

        public DALMissionTheme(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Theme>> GetMissionThemes()
        {
            return await _context.Themes.ToListAsync();
        }

        public async Task<string> CreateMissionTheme(Theme model)
        {
            // Check for duplicate entries
            bool exists = await _context.Themes.AnyAsync(t => t.ThemeName == model.ThemeName);
            if (exists)
            {
                return "Duplicate theme name. A theme with this name already exists.";
            }

            // Add the theme if it doesn't exist
            await _context.Themes.AddAsync(model);
            await _context.SaveChangesAsync();
            return "Mission theme created successfully.";
        }

        public async Task<string> UpdateMissionTheme(int missionThemeId, Theme model)
        {
            var existingTheme = await _context.Themes.FindAsync(missionThemeId);
            if (existingTheme == null)
            {
                return "Mission theme not found.";
            }

            // Check for duplicate entries
            bool exists = await _context.Themes.AnyAsync(t => t.ThemeName == model.ThemeName && t.ThemeId != missionThemeId);
            if (exists)
            {
                return "Duplicate theme name. A theme with this name already exists.";
            }

            existingTheme.ThemeName = model.ThemeName;
            existingTheme.ThemeDescription = model.ThemeDescription;
            existingTheme.ThemeImage = model.ThemeImage;

            _context.Themes.Update(existingTheme);
            await _context.SaveChangesAsync();
            return "Mission theme updated successfully.";
        }

        public async Task<Theme> GetMissionThemeById(int missionThemeId)
        {
            return await _context.Themes.FindAsync(missionThemeId);
        }

        public async Task<string> DeleteMissionTheme(int id)
        {
            var theme = await _context.Themes.FindAsync(id);
            if (theme == null)
            {
                return "Mission theme not found.";
            }

            _context.Themes.Remove(theme);
            await _context.SaveChangesAsync();
            return "Mission theme deleted successfully.";
        }
    }
}
