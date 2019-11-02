import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpUserEvent } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/';
import 'rxjs/add/operator/do';


@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    constructor(private router: Router){}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        //Если запрос не авторизован, пропуск запроса
        if (req.headers.get('No-Auth') == "True")
        return next.handle(req.clone());

        if (localStorage.getItem('token') != null) {
            const clonedreq = req.clone({
                headers: req.headers.set("Authorization", "Bearer " + localStorage.getItem('token'))
            })
            return next.handle(clonedreq)
            .do(
                success => { },
                error => {
                    if (error.status === 401)
                    this.router.navigateByUrl('/authorization');
                }
            );
        }
    }
}