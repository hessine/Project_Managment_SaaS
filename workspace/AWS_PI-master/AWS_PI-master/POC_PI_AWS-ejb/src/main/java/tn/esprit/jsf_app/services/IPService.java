package tn.esprit.jsf_app.services;

import java.io.IOException;
import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.List;

import javax.ejb.LocalBean;
import javax.ejb.Stateless;
import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.Invocation;
import javax.ws.rs.client.WebTarget;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.util.EntityUtils;
import org.json.JSONObject;

@Stateless
@LocalBean
public class IPService {
	
	public static final String endpoint = "http://ip-api.com/json";
	
	public String getIpFromRestWebService() {
		HttpClient client = new DefaultHttpClient();
		HttpGet request = new HttpGet(endpoint);
		String ip = "not found";
		try {
			HttpResponse response = client.execute(request);
			String jsonResponse = EntityUtils.toString(response.getEntity());
			System.out.println("Response as String : " + jsonResponse);
			JSONObject responseObj = new JSONObject(jsonResponse);
								
			ip = responseObj.getString("query");
		} catch (IOException e) {
			e.printStackTrace();
		}
		
		return ip;	
	}

	public String getCityFromRestWebService() {
		HttpClient client = new DefaultHttpClient();
		HttpGet request = new HttpGet(endpoint);
		String city = "not found";
		try {
			HttpResponse response = client.execute(request);
			String jsonResponse = EntityUtils.toString(response.getEntity());
			System.out.println("Response as String : " + jsonResponse);
			JSONObject responseObj = new JSONObject(jsonResponse);
								
			city = responseObj.getString("city");
		} catch (IOException e) {
			e.printStackTrace();
		}
		
		return city;	
	}
	
	public String getCountryFromRestWebService() {
		HttpClient client = new DefaultHttpClient();
		HttpGet request = new HttpGet(endpoint);
		String country = "not found";
		try {
			HttpResponse response = client.execute(request);
			String jsonResponse = EntityUtils.toString(response.getEntity());
			System.out.println("Response as String : " + jsonResponse);
			JSONObject responseObj = new JSONObject(jsonResponse);
								
			country = responseObj.getString("country");
		} catch (IOException e) {
			e.printStackTrace();
		}
		getUsers();
		return country;	
	}
	
	
	
//	public String getAllInfoFromRestWebService() {
//		Client client = ClientBuilder.newClient();
//		   Object jsons =
//		           client.target(endpoint)
//		           .request(MediaType.APPLICATION_JSON).get(Object.class);
//
//		   if (jsons instanceof JsonArray) {
//			JsonArray jsonss = (JsonArray) jsons;
//			   for (JsonValue jsonValue : jsonss) {
//				     JsonObject json = (JsonObject) jsonValue;
//				     System.out.println(json.getString("as"));
//				     System.out.println(json.getInt("city"));
//				     System.out.println(json.getInt("isp"));
//
//				   }
//		}else {
////			System.out.println("test : " + JSONObject.valueToString(jsons));
////			((JsonObject)jsons).getJsonString("as");
//			System.out.println(((JsonObject)jsons).getJsonString("as"));
//						System.out.println("test : ");
//			JSONArray inputArray = new JSONArray(JSONObject.valueToString(jsons));
//			JSONObject jo = inputArray.getJSONObject(0);
//			System.out.println("test : " + jo.getString("as"));
//		}
//
//		return null;   
		
		
//	}
	
	//http://www.javainterviewpoint.com/jersey-restful-web-services-generictype/
	public void getUsers(){
		Client client = ClientBuilder.newClient();
		WebTarget webTarget = client.target("http://jsonplaceholder.typicode.com/posts") ;
		 
		Invocation.Builder invocationBuilder =  webTarget.request(MediaType.APPLICATION_JSON);
		Response response = invocationBuilder.get();
		 
		Post[] posts =  response.readEntity(Post[].class);
		     
		System.out.println("Status : " + response.getStatus());
		
		for (int index = 0; index < posts.length; index++) {
			System.out.println(posts[index]);
		}
	}


	

}
