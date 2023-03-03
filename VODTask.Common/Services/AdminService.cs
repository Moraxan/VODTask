


using System.Text;

namespace VODTask.Common.Services
{
	public class AdminService : IAdminService
	{
		private readonly MembershipHTTPClient _http;

		public AdminService(MembershipHTTPClient http)
		{
			_http = http;
		}
		public async Task<TDto> SingleAsync<TDto>(string uri)
		{
			try
			{
				using HttpResponseMessage response = await _http.Client.GetAsync(uri);
				response.EnsureSuccessStatusCode();

				var result = JsonSerializer.Deserialize<TDto>(await response.Content.ReadAsStringAsync(),
					new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

				return result;
			}
			catch (Exception)
			{

				throw;
			}
		}
		public async Task<List<TDto>> GetAsync<TDto>(string uri)
		{
			try
			{
				using HttpResponseMessage response = await _http.Client.GetAsync(uri);
				response.EnsureSuccessStatusCode();

				var result = JsonSerializer.Deserialize<List<TDto>>(await response.Content.ReadAsStringAsync(),
					new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

				return result ?? new List<TDto>();
			}
			catch (Exception)
			{

				throw;
			}
		}
		public async Task CreateAsync<TDto>(string uri, TDto dto)
		{
			try
			{
				using StringContent jsonContent = new(
					JsonSerializer.Serialize(dto),
					Encoding.UTF8,
					"application/json");
				using HttpResponseMessage response = await _http.Client.PostAsync(uri, jsonContent);

				response.EnsureSuccessStatusCode();
			}
			catch (Exception)
			{

				throw;
			}
		}
		public async Task EditAsync<TDto>(string uri, TDto dto)
		{
			try
			{
				using StringContent jsonContent = new(
					JsonSerializer.Serialize(dto),
					Encoding.UTF8,
					"application/json");
				using HttpResponseMessage response = await _http.Client.PutAsync(uri, jsonContent);

				response.EnsureSuccessStatusCode();
			}
			catch (Exception)
			{

				throw;
			}
		}
		public async Task DeleteAsync<TDto>(string uri)
		{
			try
			{
				using HttpResponseMessage response = await _http.Client.DeleteAsync(uri);

				response.EnsureSuccessStatusCode();
			}
			catch (Exception)
			{

				throw;
			}
		}

	}
}

