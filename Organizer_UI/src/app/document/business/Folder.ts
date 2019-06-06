export class Folder {
        public Id: number;
        public Name: string;
        public Code: string;
        public ColorCode: string;
        public ParentId: number;
        public ChildIds: string;
        public Children: Folder[];
        public CreateDate: Date;
        public CreateUserId: number;
        public UpdateDate: Date;
        public UpdateUserId: number;
        public DeleteDate: Date;
        public DeleteUserId: number;
        public Status: number;

        public isOnProcess: boolean;
        public isButtonsEnabled: boolean;
        
    constructor(
        // public Id: number,
        // public Name: string,
        // public Code: string,
        // public ColorCode: string,
        // public ParentId: number,
        // public ChildIds: number[],
        // public Children: Folder[],
        // public CreateDate: Date,
        // public CreateUserId: number,
        // public UpdateDate: Date,
        // public UpdateUserId: number,
        // public DeleteDate: Date,
        // public DeleteUserId: number,
        // public Status: number
        ) {
            this.isOnProcess = true;
            this.isButtonsEnabled = false;
         }
    }

