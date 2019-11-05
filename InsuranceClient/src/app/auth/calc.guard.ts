import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CalcGuard implements CanActivate {

  constructor(private router: Router){}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot):  boolean | UrlTree {
      if (localStorage.getItem('policyCost') != null)
      return true;
      this.router.navigate(['../']);
      return false;
  }
  
}
