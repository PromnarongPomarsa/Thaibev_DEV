export interface ListQuestionDto {
    id: number;
    question?: string;
    answer?: string;
    choiceItems?: ListChoiceItemDto[];
    createDate?: Date;
}

export interface ListChoiceItemDto {
    id: number;
    reqQuestionId?: number;
    choiceText?: string;
    isCorrect?: string;
    createDate?: Date;
}