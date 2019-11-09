import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { StoreService } from '../services/store.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router, private storeService: StoreService){}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot):  boolean | UrlTree {
      if (localStorage.getItem('token') != null)
      return true;
      this.router.navigate(['/authorization']);
      return false;
  }  
}
