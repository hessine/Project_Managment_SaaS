package services;


import java.io.StringReader;
import java.util.ArrayList;
import java.util.List;

import javax.ejb.LocalBean;
import javax.ejb.Stateless;
import javax.json.Json;
import javax.json.JsonArray;

import javax.json.JsonReader;
import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.WebTarget;
import javax.ws.rs.core.Response;

import DTO.Category;
import DTO.TaskPM; 



import javax.ws.rs.client.Entity;


import javax.ws.rs.core.MediaType;





/**
 * Session Bean implementation class DemandeurConsom
 * @param <Meeting>
 */
@Stateless
@LocalBean
public class TaskConsommationService implements TaskConsommationServiceRemote {


    public TaskConsommationService() {
        // TODO Auto-generated constructor stub
    }

    public List<TaskPM> consommation()
    {
    	List<TaskPM>  lasp = new ArrayList<TaskPM>();
    	Client client = ClientBuilder.newClient();
    	
    	WebTarget web = client.target("http://localhost:2212/api/task"); 
    	
    	Response response = web.request().get();
    	
    	String result = response.readEntity(String.class); 
    	
    	//System.out.println(result);
    	JsonReader jsonReader = Json.createReader(new StringReader(result));
    	JsonArray object =  jsonReader.readArray();
    
    	for (int i=0;i<object.size();i++)
    	{
    	 
    		TaskPM m = new TaskPM();
        m.setTaskId(Integer.parseInt(object.getJsonObject(i).get("TaskId").toString()));
    	 m.setName(object.getJsonObject(i).get("Name").toString()); 
    	// m.setDate(object.getJsonObject(i).get("Date").toString()); 
    	 m.setStatus(object.getJsonObject(i).get("Status").toString()); 
    	 m.setEndDate(object.getJsonObject(i).get("EndDate").toString()); 
    	 m.setStartDate(object.getJsonObject(i).get("StartDate").toString()); 
    	 m.setDeadLine(object.getJsonObject(i).get("DeadLine").toString()); 
    	 

    	 m.setProjectName(object.getJsonObject(i).get("ProjectName").toString()); 




    	 lasp.add(m);
    	}
    	

return lasp;    	
    }
    
    
    

    @Override
  	public void Create(TaskPM p) {
  		Client client = ClientBuilder.newClient();
  		WebTarget target = client.target("http://localhost:2212/api/taskP");
  		WebTarget hello =target.path("");
  		
  		Response response =hello.request().post(Entity.entity(p, MediaType.APPLICATION_JSON) );
  		
  		String result=response.readEntity(String.class);
  		System.out.println(result);
  		System.out.println("newwwwwwwwwwwwwwwwwwwwwwwwwwwww");


  		response.close();
  		
  		
  	}
    
    
  	@Override
  	public void Update(TaskPM p , int id) {
  		Client client = ClientBuilder.newClient();
  		WebTarget target = client.target("http://localhost:2212/api/taskUp?id="+id);
  		WebTarget hello =target.path("");
  		
  		Response response =hello.request().put(Entity.entity(p, MediaType.APPLICATION_JSON) );
  		
  		String result=response.readEntity(String.class);
  		System.out.println(result);

  		response.close();
  		
  	}
    
  	@Override
	public void DelTask(int id) {
  		System.out.println("iddddddddd"+id);

		Client client = ClientBuilder.newClient();
		WebTarget target = client.target("http://localhost:2212/api/task/"+id);
		WebTarget hello =target.path("");
		Response response =hello.request(MediaType.APPLICATION_JSON_TYPE, MediaType.TEXT_PLAIN_TYPE).delete();
		
		 System.out.println("LOG DELETED"+response.getStatus());	
		String result=response.readEntity(String.class);
		System.out.println("XXXXXXXXXXX:"+result);
		
		response.close();
		
	}

	@Override
	public void putTask(int id, TaskPM p) {
		// TODO Auto-generated method stub
		TaskPM task = new TaskPM();
       task.setStartDate(p.StartDate);
       task.setEndDate(p.EndDate);
        task.setName(p.Name);
  		System.out.println("iddddddddd"+id);
  		System.out.println("OK");

		Client client = ClientBuilder.newClient();
		WebTarget target = client.target("http://localhost:2212/api/taskUp?id="+id);
		Response response = target
		                 .request()
		                 .put(Entity.entity(task, MediaType.APPLICATION_JSON));
		   System.out.println(response);
			}
  	

	

	
}
