package services;

import java.io.StringReader;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import javax.ejb.LocalBean;
import javax.ejb.Stateful;
import javax.json.Json;
import javax.json.JsonArray;
import javax.json.JsonReader;
import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.Entity;
import javax.ws.rs.client.WebTarget;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;


import DTO.Category;

@Stateful
@LocalBean
public class Test implements TestRemote {

	@Override
	public List<Category> Consommation() {
		List<Category>  lasp = new ArrayList<Category>();
    	Client client = ClientBuilder.newClient();
    	
    	WebTarget web = client.target("http://nevertouch-env.inmhukdwxm.eu-west-1.elasticbeanstalk.com/api/GetCat/"); 
    	
    	Response response = web.request().get();
    	
    	String result = response.readEntity(String.class); 
    	
    	//System.out.println(result);
    	JsonReader jsonReader = Json.createReader(new StringReader(result));
    	JsonArray object =  jsonReader.readArray();
    	SimpleDateFormat sfd = new SimpleDateFormat("dd-MM-yyyy HH:mm:ss");
    	for (int i=0;i<object.size();i++)
    	{
    	 
    		Category m = new Category();
    	 
       	 m.setCatId(object.getJsonObject(i).getInt("CatId")); 

    	 m.setCatName(object.getJsonObject(i).getString("CatName")); 
    	
    	


    	
    	 lasp.add(m);
    	 System.out.println("SSSSS : "+lasp);
    	}
    	
    	 System.out.println("SSSSS : "+lasp);
    	return lasp;
		
	}
	public static final String baseUri = "http://nevertouch-env.inmhukdwxm.eu-west-1.elasticbeanstalk.com/api";
    private Client client = null;
    private WebTarget target = null;

    public Test() {
        client = ClientBuilder.newClient();
        target = client.target(baseUri);
    }
    
    public void reloadUri() {
        target = null;
        target = client.target(baseUri);
    }
	@Override
	public void postRequest(Category p) {

		 reloadUri();
	        Category pack = new Category();
	        pack.setCatName(p.CatName);
	       

	        target = target.path("/Category");
	// POST Request from Jersey Client
	        Response response = target.request(MediaType.APPLICATION_JSON)
	                .post(Entity.entity(pack, MediaType.APPLICATION_JSON), Response.class);
	        System.out.println(response);
	        if (response.getStatus() == 200) {
	            System.out.println("post success");

	        }
	        else System.out.println("fatal error");
	}

	@Override
	public void Consommationbyid(int id) {
		Client client = ClientBuilder.newClient();
		WebTarget target = client.target("http://nevertouch-env.inmhukdwxm.eu-west-1.elasticbeanstalk.com/api/WebCategory?id="+id);
		WebTarget hello =target.path("");
		Response response =hello.request().get();
		
		String result=response.readEntity(String.class);
		System.out.println("XXXXXXXXXXX:"+result);

		response.close();
		
	}

	@Override
	public void DelRequest(int id) {
		Client client = ClientBuilder.newClient();
		WebTarget target = client.target("http://nevertouch-env.inmhukdwxm.eu-west-1.elasticbeanstalk.com/api/WebCategory?id="+id);
		WebTarget hello =target.path("");
		Response response =hello.request(MediaType.APPLICATION_JSON_TYPE, MediaType.TEXT_PLAIN_TYPE).delete();
		
		 System.out.println("LOG DELETED"+response.getStatus());	
		String result=response.readEntity(String.class);
		System.out.println("XXXXXXXXXXX:"+result);
		
		response.close();
		
	}
	@Override
	public void putRequest(int id, Category p) {
		Category pack = new Category();
        pack.setCatName(p.CatName);
       

		Client client = ClientBuilder.newClient();
		WebTarget target = client.target("http://nevertouch-env.inmhukdwxm.eu-west-1.elasticbeanstalk.com/api/Up?id="+id);
		Response response = target
		                 .request()
		                 .put(Entity.entity(pack, MediaType.APPLICATION_JSON));
		   System.out.println(response);
		
		
	}
	
	
	
	

}
