import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { StoreService } from '../services/store.service';

@Injectable({
  providedIn: 'root'
})
export class CalcGuard implements CanActivate {

  constructor(private router: Router, private storeService: StoreService){}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot):  boolean | UrlTree {
      if (this.storeService.getItem('policyCost') != null)
      return true;
      this.router.navigate(['../']);
      return false;
  }
  
}
