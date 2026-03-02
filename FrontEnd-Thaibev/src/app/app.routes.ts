import { Routes } from '@angular/router';
import { QuizAddComponent } from './features/components/quiz-add/quiz-add.component';
import { QuizFormComponent } from './features/components/quiz-form/quiz-form.component';

export const routes: Routes = [
    // { path: '', redirectTo: 'form', pathMatch: 'full' },
    { path: '', component: QuizFormComponent },
    { path: 'add', component: QuizAddComponent },
]