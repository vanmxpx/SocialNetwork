import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Credential } from '../models';

@Injectable()
export class CredentialService {
    constructor(private http: HttpClient) { }
}