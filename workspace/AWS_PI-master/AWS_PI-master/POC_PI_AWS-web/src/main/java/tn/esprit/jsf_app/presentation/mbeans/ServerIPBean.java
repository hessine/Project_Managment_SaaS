package tn.esprit.jsf_app.presentation.mbeans;

import javax.ejb.EJB;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.RequestScoped;


import tn.esprit.jsf_app.services.IPService;

@ManagedBean
@RequestScoped
public class ServerIPBean {

	@EJB
	IPService ipService;
	
	public String getIP(){
		return ipService.getIpFromRestWebService();

	}
	
	public String getCity(){
		return ipService.getCityFromRestWebService();
	}
	
	public String getCountry(){
		return ipService.getCountryFromRestWebService();
	}
	

}
