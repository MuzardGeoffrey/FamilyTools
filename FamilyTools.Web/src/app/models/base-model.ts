export class BaseModel {
  id?: number;
  creationDate?: Date;
  updateDate?: Date;

  constructor(id?: number, creationDate?: Date, updateDate?: Date){
    this.id = id;
    this.creationDate = creationDate;
    this.updateDate = updateDate;
  }

}