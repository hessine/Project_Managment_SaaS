package DTO;

import java.io.Serializable;


public class Category implements Serializable {
	public int CatId;
	public String CatName;
	public int getCatId() {
		return CatId;
	}
	public Category(String catName) {
		super();
		CatName = catName;
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
	@Override
	public String toString() {
		return "Category [CatId=" + CatId + ", CatName=" + CatName + "]";
	}
	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + CatId;
		result = prime * result + ((CatName == null) ? 0 : CatName.hashCode());
		return result;
	}
	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		Category other = (Category) obj;
		if (CatId != other.CatId)
			return false;
		if (CatName == null) {
			if (other.CatName != null)
				return false;
		} else if (!CatName.equals(other.CatName))
			return false;
		return true;
	}
	public Category() {
		super();
	}
	public Category(int catId, String catName) {
		super();
		CatId = catId;
		CatName = catName;
	}
		
	
	

}
