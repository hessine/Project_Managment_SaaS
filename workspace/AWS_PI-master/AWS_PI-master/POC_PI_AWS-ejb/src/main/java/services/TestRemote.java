package services;

import java.util.List;

import javax.ejb.Remote;

import DTO.Category;

@Remote
public interface TestRemote {

	List<Category> Consommation();
	void postRequest(Category p);
	void Consommationbyid(int id);
	void DelRequest(int id);
	void putRequest(int id, Category p);

}
