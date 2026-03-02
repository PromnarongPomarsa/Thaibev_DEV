import { Component, inject, OnInit, OnDestroy } from '@angular/core';
import { FormsModule } from '@angular/forms';

// import primeNG
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { Button } from "primeng/button";
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';

//service api
import { ApiService } from '../../../services/api.service';

//import model
import { ListQuestionDto } from '../../../models/ListQuestionDto';
import { ResponseDto } from '../../../models/ResponseDto.modal';
import { MsgDto } from '../../../models/MsgDto.modal';


@Component({
  selector: 'app-quiz-add',
  standalone: true,
  imports: [
    Button,
    ButtonModule,
    InputTextModule,
    FormsModule,
  ],
  templateUrl: './quiz-add.component.html',
  styleUrl: './quiz-add.component.css',
  providers: []
})
export class QuizAddComponent implements OnInit {
  public ref = inject(DynamicDialogRef);
  public dialogService = inject(DialogService);

  nonItems: string = "";
  questions: ListQuestionDto = {
    id: 0,
    question: '',
    choiceItems: [],
  };
  choiceItems: any[] = [];

  constructor(private _apiService: ApiService) { }

  ngOnInit(): void {
    this.defineValue();
    this.getMsg();
  }

  defineValue() {
    this.choiceItems = [
      { reqQuestionId: 0, choiceText: '', isCorrect: 'Y', createDate: new Date() },
      { reqQuestionId: 0, choiceText: '', isCorrect: 'N', createDate: new Date() },
      { reqQuestionId: 0, choiceText: '', isCorrect: 'N', createDate: new Date() },
      { reqQuestionId: 0, choiceText: '', isCorrect: 'N', createDate: new Date() }
    ];
  }

  getMsg() {
    this._apiService.getAllMsg().subscribe({
      next: (response: ResponseDto<MsgDto[]>) => {
        if (response.isSuccess == true) {
          this.nonItems = response.result.find((msg: MsgDto) => msg.msgCode === 'T002')?.msgDesc || "";
          console.log("nonItems: ", this.nonItems);
        }
      },
      error: (error) => {
        console.log("Error getMsg: ", error);
      }
    });
  }



  async saveData() {
    const valiData = await this.validation();

    if (!valiData) {
      return;
    }

    this.questions.choiceItems = this.choiceItems;
    this._apiService.saveQuestion(this.questions).subscribe({
      next: (response: ResponseDto<ListQuestionDto[]>) => {
        if (response.isSuccess == true) {
          this.ref?.close(response);
        }
      },
      error: (error) => {
        console.log("Error getQuestionData: ", error)
      }
    })
  }

  cancel() {
    this.ref?.close();
    console.log('cancel', this.ref);
  }

  async validation() {
    const validateQuestion = this.questions.question && this.questions.question.trim() !== '';
    const validateData = this.choiceItems.every(item => item.choiceText && item.choiceText.trim() !== '');

    if (!validateQuestion) {
      alert(this.nonItems);
      return false;
    }
    return validateData;
  }

  ngOnDestroy() {
  }

}
