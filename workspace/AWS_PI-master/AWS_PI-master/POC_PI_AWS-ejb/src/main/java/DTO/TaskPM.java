package DTO;

import java.util.Date;



public class TaskPM {


	  
	
		
		protected int TaskId;
		public  String StartDate;		
		public  String EndDate;
		protected  String DeadLine;
		public  String Name;
		protected  String Status;
		protected  String leader;
		protected  String ProjectName;
		protected  int ProjectId;
		protected  String UserId;



		
		
		public TaskPM() {
			super();
		}


	
		
		

		public int getTaskId() {
			return TaskId;
		}

	





	




		public TaskPM(String startDate, String endDate, String deadLine, String name, String status, String leader) {
			super();
			StartDate = startDate;
			EndDate = endDate;
			DeadLine = deadLine;
			Name = name;
			Status = status;
			this.leader = leader;
		}










//ce cons que j ai suivi pour l ajout
		public TaskPM(String startDate, String endDate, String deadLine, String name, String status, String leader,
				int projectId, String userId) {
			super();
			StartDate = startDate;
			EndDate = endDate;
			DeadLine = deadLine;
			Name = name;
			Status = status;
			this.leader = leader;
			ProjectId = projectId;
			UserId = userId;
		}






		public TaskPM(String startDate, String endDate, String deadLine, String name, String status, String leader,
				String projectName) {
			super();
			StartDate = startDate;
			EndDate = endDate;
			DeadLine = deadLine;
			Name = name;
			Status = status;
			this.leader = leader;
			ProjectName = projectName;
		}






		public TaskPM(String startDate, String deadLine, String name) {
			super();
			StartDate = startDate;
			DeadLine = deadLine;
			Name = name;
		}










		public TaskPM(String name) {
			super();
			Name = name;
		}






		public int getProjectId() {
			return ProjectId;
		}






		public void setProjectId(int projectId) {
			ProjectId = projectId;
		}

















		public TaskPM(int taskId, String startDate, String endDate, String deadLine, String name, String status,
				String leader, String projectName) {
			super();
			TaskId = taskId;
			StartDate = startDate;
			EndDate = endDate;
			DeadLine = deadLine;
			Name = name;
			Status = status;
			this.leader = leader;
			ProjectName = projectName;
		}






		public void setTaskId(int taskId) {
			TaskId = taskId;
		}




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






		public String getStartDate() {
			return StartDate;
		}






		public void setStartDate(String startDate) {
			StartDate = startDate;
		}






		public String getEndDate() {
			return EndDate;
		}






		public void setEndDate(String endDate) {
			EndDate = endDate;
		}






		public String getDeadLine() {
			return DeadLine;
		}






		public void setDeadLine(String deadLine) {
			DeadLine = deadLine;
		}






		public String getProjectName() {
			return ProjectName;
		}






		public void setProjectName(String projectName) {
			ProjectName = projectName;
		}






		@Override
		public String toString() {
			return "TaskPM [TaskId=" + TaskId + ", StartDate=" + StartDate + ", EndDate=" + EndDate + ", DeadLine="
					+ DeadLine + ", Name=" + Name + ", Status=" + Status + ", leader=" + leader + "]";
		}
	

}
