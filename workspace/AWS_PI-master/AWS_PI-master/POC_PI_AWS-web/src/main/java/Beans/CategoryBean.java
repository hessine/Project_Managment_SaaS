package Beans;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.faces.application.FacesMessage;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.context.FacesContext;
import DTO.Category;
import services.Test;



@ManagedBean
@SessionScoped
public class CategoryBean {
	public int CatId;
	public String CatName;
	Category packs;
	public static List<Category> packss;
	private List<Category> listOfTask = new ArrayList<Category>();
	public int packIdToBeUpdate;
	private List<Category> Categories;
	
	public CategoryBean() {}
	
	

	@EJB
	Test pack;

	public int getCatId() {
		return CatId;
	}

	public void setCatId(int catId) {
		CatId = catId;
	}

	public String getCatName() {
		return CatName;
	}

	public void setCatName(String catName) {
		CatName = catName;
	}

	public Category getPacks() {
		return packs;
	}

	public void setPacks(Category packs) {
		this.packs = packs;
	}

	public static List<Category> getPackss() {
		return packss;
	}

	public static void setPackss(List<Category> packss) {
		CategoryBean.packss = packss;
	}

	public List<Category> getListOfTask() {
		return listOfTask;
	}

	

	public List<Category> getCategories() {
		return Categories;
	}

	public void setCategories(List<Category> categories) {
		Categories = categories;
	}
		
	public List<Category> getINF() {
		packss = pack.Consommation();
		return packss;
	}

	public List<Category> getPackss1() {
		return packss;
	}

	public void setPackss1(List<Category> packss) {
		this.packss = packss;
	}

	public void getPack() {
		packss = new ArrayList<>();
		packss = pack.Consommation();
	}

	public void setPack(Test pack) {
		this.pack = pack;
	}
	public List<Category> getListOfTask1() {
		return listOfTask;
	}
	public void setListOfTask(List<Category> listOfTask) {
		this.listOfTask = listOfTask;
	}
	@PostConstruct
	public void init() {
		listOfTask = pack.Consommation();
	}
	Category lloo = new Category("ssds");
	
	public Category getLloo() {
		return lloo;
	}

	public void setLloo(Category lloo) {
		this.lloo = lloo;
	}

	public List<Category> geeeettttetAllTasks() {
		return listOfTask;
	}
	public String supprimerssss(Integer packId) {
		pack.DelRequest(packId);
		return "/Try?faces-redirect=true"	;	
	}
	public void modifier(Category cat){	
	
			//navigateTo ="/pages/admin/listEmploye?faces-redirect=true";
			//loggedIn = true;

			this.setCatName(cat.getCatName());
			this.setCatId(cat.getCatId());
		
	}
	
	public void mettreAjourEmploye(){
		
		pack.putRequest(CatId,new Category(CatName));
		
	}
	
	
	public void addCategory(){
		
		pack.postRequest(new Category(CatName));
		
	}
	
	
}

	
	
	
	

