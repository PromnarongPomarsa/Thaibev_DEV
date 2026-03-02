import { Component, inject, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

// PrimeNG imports
import { ButtonModule } from 'primeng/button';
import { FormsModule } from '@angular/forms';
import { RadioButtonModule } from 'primeng/radiobutton';
import { CardModule } from 'primeng/card';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';


// Import the component
import { QuizAddComponent } from '../quiz-add/quiz-add.component';

//import model
import { ResponseDto } from '../../../models/ResponseDto.modal';
import { MsgDto } from '../../../models/MsgDto.modal';
import { ListQuestionDto } from '../../../models/ListQuestionDto';

//service api
import { ApiService } from '../../../services/api.service';
import { QuestionIdDto } from '../../../models/QuestionIdDto';

@Component({
  selector: 'app-quiz-form',
  standalone: true,
  imports: [
    CommonModule,
    RadioButtonModule,
    ButtonModule,
    FormsModule,
    CardModule
  ],
  templateUrl: './quiz-form.component.html',
  styleUrl: './quiz-form.component.css',
  providers: []
})
export class QuizFormComponent implements OnInit {
  // open modal
  ref: DynamicDialogRef | null = null;
  public dialogService = inject(DialogService);

  // variables for quiz form
  isLoading: boolean = false;
  displayItems = false;
  nonItems: string = "";
  questions: ListQuestionDto[] = [];
  constructor(
    private _apiService: ApiService,
    router: Router) { }

  ngOnInit() {
    this.getMsg();
    this.getQuestionsData();
  }

  getQuestionsData() {
    this.isLoading = true;
    this._apiService.getQuestions().subscribe({
      next: (response: ResponseDto<ListQuestionDto[]>) => {
        this.isLoading = false;
        this.questions = response.result ? response.result : [];
        console.log("questions: ", this.questions);
      },
      error: (error) => {
        console.log("Error getQuestionData: ", error)
      }
    })
  }

  getMsg() {
    this.isLoading = true;
    this._apiService.getAllMsg().subscribe({
      next: (response: ResponseDto<MsgDto[]>) => {
        this.isLoading = false;
        if (response.isSuccess == true) {
          this.nonItems = response.result.find((msg: MsgDto) => msg.msgCode === 'T001')?.msgDesc || "";
          console.log("nonItems: ", this.nonItems);
        }
      },
      error: (error) => {
        console.log("Error getMsg: ", error);
      }
    });
  }

  addQuestion() {
    this.ref = this.dialogService.open(QuizAddComponent, {
      header: 'IT 08-2',
      width: '50%',
      modal: true,
      closable: true,
      styleClass: 'quiz-page'
    });

    this.ref?.onClose.subscribe((result: ResponseDto<any>) => {
      this.getQuestionsData();
    });
  }

  deleteQuestion(id: number) {
    let provideData: QuestionIdDto = {
      questionId: id
    }
    this.isLoading = true;
    this._apiService.deleteQuestion(provideData).subscribe({
      next: (response: ResponseDto<null>) => {
        this.isLoading = false;
        if (response.isSuccess == true) {
          this.getQuestionsData();
        }
        console.log("questions: ", this.questions);
      },
      error: (error) => {
        console.log("Error getQuestionData: ", error)
      }
    })

  }

  ngOnDestroy() {
    if (this.ref) {
      this.ref.close();
    }
  }

}
