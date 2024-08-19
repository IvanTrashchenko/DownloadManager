import { CanActivate, ActivatedRouteSnapshot, UrlTree, RouterStateSnapshot, Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { map, take } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(
        private authService: AuthService,
        private router: Router,
    ) {

    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        const token = this.authService.authToken;
        if (token && !this.authService.isTokenExpired()) {
            return true;
        } else {
            this.router.navigate(['/auth/login']);
            return false;
        }
    }
}
