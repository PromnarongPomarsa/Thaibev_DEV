import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

// import model
import { ListQuestionDto } from '../models/ListQuestionDto';
import { QuestionIdDto } from '../models/QuestionIdDto';

import { environment } from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class ApiService {
    private http = inject(HttpClient);
    constructor() { }
    apiUrl = environment.apiUrl;

    getAllMsg(): Observable<any> {
        return this.http.get(`${this.apiUrl}/api/quiz/get-all-msg`);
    }

    getQuestions(): Observable<any> {
        return this.http.get(`${this.apiUrl}/api/quiz/get-question`);
    }

    saveQuestion(data: ListQuestionDto): Observable<any> {
        return this.http.post(`${this.apiUrl}/api/quiz/save-question`, data);
    }

    deleteQuestion(questionId: QuestionIdDto): Observable<any> {
        return this.http.post(`${this.apiUrl}/api/quiz/delete-question`, questionId);
    }
}
