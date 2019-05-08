package Beans;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;

import DTO.TaskPM;
import services.TaskConsommationService;



@ManagedBean
@SessionScoped
public class TaskConBean {

	
	
	
	protected int TaskId;
	protected  String StartDate;		
	protected  String EndDate;
	protected  String DeadLine;
	protected  String Name;
	protected  String Status;
	protected  String leader;
	protected  int ProjectId;
	protected  String UserId;
	
	private List<TaskPM> listOfTask = new ArrayList<TaskPM>();
	@EJB
	TaskConsommationService taskConService;

	
	
	public String getName() {
		return Name;
	}
	public void setName(String name) {
		Name = name;
	}
	public String getStatus() {
		return Status;
	}
	public void setStatus(String status) {
		Status = status;
	}
	
	
	
	
	
	
	

	
	
	public String getDeadLine() {
		return DeadLine;
	}
	public void setDeadLine(String deadLine) {
		DeadLine = deadLine;
	}
	public int getTaskId() {
		return TaskId;
	}
	public void setTaskId(int taskId) {
		TaskId = taskId;
	}
	public String getStartDate() {
		return StartDate;
	}
	public void setStartDate(String startDate) {
		StartDate = startDate;
	}
	
	
	
	public int getProjectId() {
		return ProjectId;
	}
	public void setProjectId(int projectId) {
		ProjectId = projectId;
	}

	
	
	
	
	public String getLeader() {
		return leader;
	}
	public void setLeader(String leader) {
		this.leader = leader;
	}
	public String getUserId() {
		return UserId;
	}
	public void setUserId(String userId) {
		UserId = userId;
	}
	public String getEndDate() {
		return EndDate;
	}
	public void setEndDate(String endDate) {
		EndDate = endDate;
	}
	public List<TaskPM> getListOfTask() {
		return listOfTask;
	}
	public void setListOfTask(List<TaskPM> listOfTask) {
		this.listOfTask = listOfTask;
	}
	@PostConstruct
	public void init() {
		listOfTask = taskConService.consommation();
	}
	
	public List<TaskPM> getAllTasks() {

		return listOfTask;
	}
	
	
	public void doAddTask() {

		//taskConService.Create(new TaskPM("nnnnn"));
	//taskConService.Create(new TaskPM(Name));

//	taskConService.Create(new TaskPM(StartDate,DeadLine,Name));
		
		
	taskConService.Create(new TaskPM(StartDate,"2015-05-20T00:00:00",
			DeadLine,Name,"todo","a9f29e2e-515c-4258-a623-938cb5891c72",1,
			"a9f29e2e-515c-4258-a623-938cb5891c72"));

	
		listOfTask = taskConService.consommation();


	}
	
	
	
	//cette fonction est inutilisable
	public void doUpTask() {

		taskConService.Update(new TaskPM(StartDate,EndDate,Name),TaskId);
		listOfTask = taskConService.consommation();
	}
	
	public String DeleteTask(Integer tasId) {
		taskConService.DelTask(tasId);
		//return "";
		listOfTask = taskConService.consommation();

		return "/ListTask?faces-redirect=true"	;

	}
	
	
	public void modifier(TaskPM task){	
		
		//navigateTo ="/pages/admin/listEmploye?faces-redirect=true";
		//loggedIn = true;

		this.setName(task.getName());
		this.setStartDate(task.getStartDate());
		this.setEndDate(task.getEndDate());

		this.setTaskId(task.getTaskId());
	
}

public void mettreAjourTask(){
	
	taskConService.putTask(TaskId,new TaskPM(Name));
	listOfTask = taskConService.consommation();

}

	
}
