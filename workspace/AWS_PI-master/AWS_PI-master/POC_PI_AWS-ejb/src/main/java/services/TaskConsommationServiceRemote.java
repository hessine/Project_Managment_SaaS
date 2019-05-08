
package services;

import java.util.List;

import javax.ejb.Remote;

import DTO.Category;
import DTO.TaskPM; 




public interface TaskConsommationServiceRemote {


	public List<TaskPM>  consommation();

  	public void Update(TaskPM p , int id);
  	public void Create(TaskPM p);
	public void DelTask(int id);

	public void putTask(int id, TaskPM p);



}
