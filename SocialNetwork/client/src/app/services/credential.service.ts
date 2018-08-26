import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Credential } from '../models';

@Injectable()
export class CredentialService {
    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get<Credential[]>(`${environment.apiUrl}/authorizations`);
    }
    
    addAuthorization(credential: Credential) {
        return this.http.post(`${environment.apiUrl}/authorizations/`, credential);
    }

    getById(id: number) {
        return this.http.get(`${environment.apiUrl}/authorizations/` + id);
    }
    
    delete(id: number) {
        return this.http.delete(`${environment.apiUrl}/authorizations/` + id);
    }
}