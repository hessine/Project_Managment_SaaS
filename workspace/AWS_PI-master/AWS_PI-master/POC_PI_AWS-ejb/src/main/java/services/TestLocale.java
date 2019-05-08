package services;

import java.util.List;

import javax.ejb.Local;

import DTO.Category;

@Local
public interface TestLocale {
	List<Category> Consommation();
	void postRequest(Category p);
	void Consommationbyid(int id);
	void DelRequest(int id);
	void putRequest(int id, Category p);
}
