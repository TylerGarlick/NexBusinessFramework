using Newtonsoft.Json;


public static class ObjectHelpers {

	public static string ToJson(this object obj) {
		return JsonConvert.SerializeObject(obj);
	}
}

