import { Injectable } from '@angular/core';
import { Router, NavigationStart } from '@angular/router';
import { Observable, Subject } from 'rxjs';

@Injectable()
export class AlertService {
    private subject = new Subject<any>();
    private keepAfterNavigationChange = false;

    constructor(private router: Router) {
        // очистить сообщение об изменении маршрута
        router.events.subscribe(event => {
            if (event instanceof NavigationStart) {
                if (this.keepAfterNavigationChange) {
                    // сохранить только одно изменение местоположения
                    this.keepAfterNavigationChange = false;
                } else {
                    // удаляем сообщение
                    this.subject.next();
                }
            }
        });
    }

    //callback функция при удачи
    success(message: string, keepAfterNavigationChange = false) {
        this.keepAfterNavigationChange = keepAfterNavigationChange;
        this.subject.next({ type: 'success', text: message });
    }
    //callback функция при неудачи
    error(message: string, keepAfterNavigationChange = false) {
        this.keepAfterNavigationChange = keepAfterNavigationChange;
        this.subject.next({ type: 'error', text: message });
    }
    
    getMessage(): Observable<any> {
        return this.subject.asObservable();
    }
}